public interface IPowerConsumer
{
    // Thiết bị này có đang ngốn điện không?
    bool IsConsumingPower { get; }

    // Mức ngốn điện mỗi giây (+1f, +1.5f,...)
    float PowerDrainRate { get; }
}