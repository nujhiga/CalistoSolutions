namespace CalistoStandards.Definitions.Enumerations;

[SignMapAttr(SignMapType.ClStatusMap, typeof(ClStatus))]

public enum ClStatus
{
    None,
    Initializing,
    Working,
    Finished,
    Cancelled,
    Cancelling,
    Paused,
    Pausing
}