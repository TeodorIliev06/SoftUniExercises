using MilitaryElite.Interfaces;
using MilitaryElite.Models.Enums;
using System.Text;

namespace MilitaryElite.Models;

public class Mission : IMission
{
    public Mission(string codeName, string state)
    {
        CodeName = codeName;
        State = TryParseState(state);
    }

    public string CodeName { get; private set; }

    public State State { get; private set; }

    //We don't call this method.It just exists.
    public void CompleteMission()
    {
        if (State == State.Finished)
        {
            throw new ArgumentException("Mission is already completed!");
        }

        State = State.Finished;
    }

    public State TryParseState(string stateStr)
    {
        bool parsed = Enum.TryParse(stateStr, out State state);
        if (!parsed)
        {
            throw new ArgumentException("Invalid mission state!");
        }

        return state;
    }

    public string PrintMission()
    {
        StringBuilder sb = new();
        sb.AppendLine($"  Code Name: {CodeName} State: {State}");
        return sb.ToString().TrimEnd();
    }
}
