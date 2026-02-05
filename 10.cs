public interface ISerializableDTO
{
    int Id { get; }
}

public static class DtoSerializer
{
    public static string ToXML(ISerializableDTO dto)
    {
        return $"<{dto.GetType().Name}><Id>{dto.Id}</Id></{dto.GetType().Name}>";
    }

    public static string ToJSON(ISerializableDTO dto)
    {
        return $"{{\"Id\":{dto.Id}}}";
    }
}
