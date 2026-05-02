
namespace FinalProject{
    public class Market{

        private List<SellOrder> PendingOrders;
        private List<SellOrder> CompletedOrders;
        


        private class SellOrder{
            
            private int _price;
            private IItem _item;
            private DateTime _timeAlive;

            public SellOrder(IItem item, int price){
                this._price = price;
                this._item = item;
                _timeAlive = new DateTime();
                _timeAlive.ToLocalTime();
            }

            public int Price { get {return _price;}}
            public IItem Item {get {return _item;}}

            public string toString(){
                string output = "\t| " + _item + "... \t" + _price +"G | Alive for : " ;
                return output;
            }

        }
    }
}