public interface IInteractible
{
    bool IsActionPlayed { get; set; }
    void Action();
}