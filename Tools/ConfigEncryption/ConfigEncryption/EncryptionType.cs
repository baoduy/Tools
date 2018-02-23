namespace ConfigEncryption
{
    public enum EncryptionType
    {
        AppSettings = 1,
        ConnectionStrings = 2,
        All = AppSettings | ConnectionStrings,
        Custom = 4,
    }
}
