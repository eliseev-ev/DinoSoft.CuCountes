namespace DinoSoft.CuCounters.Data.Model
{
    public class CounterAction
    {
        public Guid Id { get; set; }
        public int Value { get; set; }
        public CounterActionType ActionType { get; set; }
        public string Title
        {
            get
            {
                if (this.ActionType == CounterActionType.Add)
                {
                    return $"+{Value}";
                }
                return $"-{Value}";
            }
        }
    }
}