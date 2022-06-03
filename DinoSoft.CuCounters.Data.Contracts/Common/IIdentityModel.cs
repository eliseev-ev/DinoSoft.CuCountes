namespace DinoSoft.CuCounters.Data.Contracts.Common
{
    /// <summary>Модель с идентификатором.</summary>
    /// <typeparam name="T">Тип идентификатора.</typeparam>
    public interface IIdentityModel<T>
    {
        /// <summary>Идентификатор.</summary>
        T Id { get; set; }
    }
}
