using System.Collections;
using System.Collections.Generic;
using System;

namespace FinalProject
{
    /*
     * Spring 2026
     * This is a simple parser. It can only accept 
     * commands with upmost 1 parameter. You may modify
     * it along with the Command Abstract class.
     */
    public class Parser
    {
        private CommandWords _commands;

        public Parser() : this(new CommandWords()){}

        // Designated Constructor
        public Parser(CommandWords newCommands)
        {
            _commands = newCommands;
        }

        public Command ParseCommand(string commandString)
        {
            Command? command = null;
            string[] words = commandString.Split(' ');
            command = _commands.Get(words[0]);
            if(command != null){
                command.ResetParams();
                if(words.Length > 0) {
                    if(command != null && words.Length >= 1){
                        for(int i = 1; i < words.Length; i++){
                            command.add(words[i].Trim());
                        }
                    }else{
                        Console.WriteLine("not written to param");
                    }
                }else{
                    Console.WriteLine("No params");
                }
            }else{
                Console.WriteLine("Please enter a valid command, type help for commands");
            }
        
            return command;
        }
        

        public string Description()
        {
            return _commands.Description();
        }
    }
}
