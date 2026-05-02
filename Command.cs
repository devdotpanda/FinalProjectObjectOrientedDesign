using System.Collections;
using System.Collections.Generic;
using System;

namespace FinalProject
{

    /*
     * Spring 2026
     * This is a single-parameter command class.
     * You may modify it to suit your needs.
     */
    public abstract class Command
    {
        private string _name;
        public string Name { get { return _name; } set { _name = value; } }
        public List<String> _parameters;
        public Command()
        {
            this.Name = "";
            _parameters = new List<string>();
        }

        public void add(string param){
            _parameters.Add(param);
        }

        public void ResetParams(){
            _parameters.Clear();
        }

        public abstract bool Execute(Player player);
    }
}
