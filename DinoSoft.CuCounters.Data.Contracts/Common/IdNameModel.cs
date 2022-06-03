namespace DinoSoft.CuCounters.Data.Contracts.Common
{
    public abstract class IdNameModel : IIdentityModel<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
