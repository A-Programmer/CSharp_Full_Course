namespace Sixeyed.Extensions.Samples.Demo6;

public class Instrumentation
{
    public Guid Id { get; set; }
    private DateTime _startedAt;
    public string ProcessName { get; set; }

    public Instrumentation() => Id = Guid.NewGuid();

    public void Start() => _startedAt = DateTime.Now;

    public int GetElapsedTime() => (int) Math.Round(new TimeSpan(DateTime.Now.Ticks - _startedAt.Ticks).TotalSeconds, 0);

}