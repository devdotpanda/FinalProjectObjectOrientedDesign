
namespace FinalProject{
    public class Market{

        private List<SellOrder> PendingOrders;
        private List<SellOrder> CompletedOrders;

        public Market(){
            PendingOrders = new List<SellOrder>();
            CompletedOrders = new List<SellOrder>();
        }

        public void CreateOrder(IItem item, int price, int amount){
            SellOrder order = new SellOrder(item, price, amount);
            PendingOrders.Add(order);
        }

        override
        public string ToString(){
            string output = "\t    ~~~~MARKET ORDERS~~~~ \n";
            for(int i = 0; i < PendingOrders.Count; i++){
                output += i + ".   " + PendingOrders[i].ToString() + " \n";
            }
            return output;
        }

        public IItem RemoveOrder(int index){
            if(PendingOrders.Count > index){
                SellOrder output = PendingOrders[index];
                PendingOrders.Remove(output);
                return output.Item;
            }else{
                Console.WriteLine("please enter a valid index");
                return null;
            }
        }

        private class SellOrder{
            
            private int _price;
            private IItem _item;
            private int _amount;
            private DateTime _timeAlive;

            public SellOrder(IItem item, int price, int amount){
                this._price = price;
                this._item = item;
                this._amount = amount;
                _timeAlive = new DateTime();
                _timeAlive.ToLocalTime();
            }

            public int Price { get {return _price;}}
            public IItem Item {get {return _item;}}
            public int Amount {get {return _amount;}}

            public string toString(){
                string output = "\t| " + _item + "... \t" + _price +"G | Alive for : " ;
                return output;
            }

        }
    }
}