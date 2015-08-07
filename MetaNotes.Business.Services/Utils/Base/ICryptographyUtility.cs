namespace MetaNotes.Business.Services
{
    /// <summary>Утилита криптографии</summary>
    public interface ICryptographyUtility
    {
        /// <summary>Вычисляет хэш код строки</summary>
        /// <param name="originalString">Исходная строка</param>
        /// <returns>Хеш код исходной строки</returns>
        string GetHash(string originalString);
    }
}
