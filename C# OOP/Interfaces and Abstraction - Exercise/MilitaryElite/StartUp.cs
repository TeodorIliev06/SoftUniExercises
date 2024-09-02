using MilitaryElite.Interfaces;
using MilitaryElite.Models;
namespace MilitaryElite;

public class StartUp //Got some ideas for the interfaces from different sources - such as enum
{
    static void Main(string[] args)
    {
        ICollection<ISoldier> soldiers = new List<ISoldier>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] soldierTokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string soldierType = soldierTokens[0];
            string id = soldierTokens[1];
            string firstName = soldierTokens[2];
            string lastName = soldierTokens[3];
            decimal salary;
            string corps;

            //We declare the soldier and then will determine his rank
            ISoldier currSoldier = null;
            switch (soldierType)
            {
                case "Private":
                    salary = decimal.Parse(soldierTokens[4]);
                    currSoldier = new Private(id, firstName, lastName, salary);
                    break;
                case "LieutenantGeneral":
                    salary = decimal.Parse(soldierTokens[4]);
                    ILieutenantGeneral general = new LieutenantGeneral(id, firstName, lastName, salary);

                    //We receive the soldier(private) and add him
                    foreach (var privateId in soldierTokens.Skip(5))
                    {
                        ISoldier privateToAdd = soldiers.First(s => s.Id == privateId);
                        general.AddPrivate((IPrivate)privateToAdd);
                    }

                    currSoldier = general;
                    break;
                case "Engineer":
                    salary = decimal.Parse(soldierTokens[4]);
                    corps = soldierTokens[5];

                    //If we receive invalid corps - we skip the entire line
                    try
                    {
                        IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);
                        string[] repairsTokens = soldierTokens.Skip(6).ToArray();

                        //Read the repair info and add it
                        for (int i = 0; i < repairsTokens.Length; i += 2)
                        {
                            string partName = repairsTokens[i];
                            int hoursWorked = int.Parse(repairsTokens[i + 1]);
                            IRepair repair = new Repair(partName, hoursWorked);
                            engineer.AddRepair(repair);
                        }

                        currSoldier = engineer;
                    }

                    catch (Exception ex)
                    {
                        //Console.WriteLine(ex.Message);
                        continue;
                    }
                    break;
                case "Commando":
                    salary = decimal.Parse(soldierTokens[4]);
                    corps = soldierTokens[5];

                    //If we receive invalid corps - we skip the entire line
                    try
                    {
                        ICommando commando = new Commando(id, firstName, lastName, salary, corps);
                        string[] missionsTokens = soldierTokens.Skip(6).ToArray();

                        //Read the mission info and add it
                        for (int i = 0; i < missionsTokens.Length; i += 2)
                        {
                            //If we receive an invalid mission state - we skip the mission only
                            try
                            {
                                string missionCodeName = missionsTokens[i];
                                string missionState = missionsTokens[i + 1];
                                IMission mission = new Mission(missionCodeName, missionState);
                                commando.AddMission(mission);
                            }

                            catch (Exception ex)
                            {
                                //Console.WriteLine(ex.Message);
                                continue;
                            }
                        }

                        currSoldier = commando;
                    }

                    catch (Exception ex)
                    {
                        //Console.WriteLine(ex.Message);
                        continue;
                    }
                    break;
                case "Spy":
                    int codeNumber = int.Parse(soldierTokens[4]);
                    currSoldier = new Spy(id, firstName, lastName, codeNumber);
                    break;
            }

            //If all input is valid - we add the soldier
            if (currSoldier is not null)
            {
                soldiers.Add(currSoldier);
            }
        }

        Console.WriteLine(string.Join(Environment.NewLine, soldiers));
    }
}
