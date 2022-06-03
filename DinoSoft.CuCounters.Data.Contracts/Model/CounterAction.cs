using DinoSoft.CuCounters.Data.Contracts.Common;

namespace DinoSoft.CuCounters.Data.Contracts.Model
{
    public class CounterAction : IIdentityModel<Guid>
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

        public Guid CounterId { get; set; }
    }
}