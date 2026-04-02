using System;

namespace FinalProject{
    public class Plant{
        private string _name;
        private string _type;
        private string _location;
        private string _quality;
        private string _effect;
        private string _effectDesc;
        private int _amount;
        private string _description;
        private string _isBoiledDesc;

        public string Name{
            get{return _name;}
            set{_name = value;}
        }

        public string Type{
            get{return _type;}
            set{_type = value;}
        }

        public string Location{
            get{return _location;}
            set{_location = value;}
        }

        public string Quality{
            get{return _quality;}
            set{_quality = value;}
        }

        public string Desc{
            get{return _description;}
            set{_description = value;}
        }


        public string toString(){
            return "\n~~~ "+_name+" ~~~ \n"+_type+"\n"+_location+"\n"+_quality+"\n"+_description+"\n";
        }
    

        //public Plant Boil(){}
        //public Plant Crush();
        //public Plant Roast();
    
    }
    
}