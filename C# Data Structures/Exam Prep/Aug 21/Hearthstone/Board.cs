using System;
using System.Collections.Generic;
using System.Linq;

public class Board : IBoard
{
    private IDictionary<string, Card> cardsByName;

    public Board()
    {
        this.cardsByName = new Dictionary<string, Card>();
    }

    public bool Contains(string name) => this.cardsByName.ContainsKey(name);

    public int Count() => this.cardsByName.Count;

    public void Draw(Card card)
    {
        if (this.cardsByName.ContainsKey(card.Name))
        {
            throw new ArgumentException(nameof(card));
        }

        this.cardsByName.Add(card.Name, card);
    }

    public IEnumerable<Card> GetBestInRange(int start, int end)
        => this.cardsByName.Values
            .Where(c => c.Score >= start && c.Score <= end)
            .OrderByDescending(c => c.Level);

    public void Heal(int health)
    {
        var card = this.cardsByName.Values
            .OrderBy(c => c.Health)
            .FirstOrDefault();

        card.Health += health;
    }

    public IEnumerable<Card> ListCardsByPrefix(string prefix)
        => this.cardsByName.Values
            .Where(c => c.Name.StartsWith(prefix))
            .OrderBy(c => String.Join("", c.Name.Reverse())) //Reverse returns IEnumerable<char> - we need diff collection to order
            .ThenBy(c => c.Level);

    public void Play(string attackerCardName, string defenderCardName)
    {
        if (!this.cardsByName.ContainsKey(defenderCardName) ||
            !this.cardsByName.ContainsKey(attackerCardName))
        {
            throw new ArgumentException();
        }

        var attacker = this.cardsByName[attackerCardName];
        var defender = this.cardsByName[defenderCardName];

        if (attacker.Level != defender.Level)
        {
            throw new ArgumentException();
        }

        if (defender.Health <= 0 || attacker.Health <= 0)
        {
            return;
        }

        defender.Health -= attacker.Damage;

        if (defender.Health <= 0)
        {
            attacker.Score += defender.Level;
        }
    }

    public void Remove(string name)
    {
        if (!this.cardsByName.ContainsKey(name))
        {
            throw new ArgumentException(nameof(name));
        }

        this.cardsByName.Remove(name);
    }

    public void RemoveDeath()
    {
        //We have to cast the IEnumerable that we get after filtering so as not to work with the projection of the deck
        var cardsToRemove = this.cardsByName.Values
            .Where(c => c.Health <= 0).ToArray();

        foreach (var card in cardsToRemove)
        {
            this.cardsByName.Remove(card.Name);
        }
    }

    public IEnumerable<Card> SearchByLevel(int level)
        => this.cardsByName.Values
            .Where(c => c.Level == level)
            .OrderByDescending(c => c.Score);

}