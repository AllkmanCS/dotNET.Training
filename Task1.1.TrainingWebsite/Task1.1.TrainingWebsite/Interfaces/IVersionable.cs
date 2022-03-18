namespace Task1.One.TrainingWebsite.Interfaces
{
    public interface IVersionable
    {
        byte[] ReadVersion(ulong version);
        ulong SetVersion(ulong version);
    }
}
