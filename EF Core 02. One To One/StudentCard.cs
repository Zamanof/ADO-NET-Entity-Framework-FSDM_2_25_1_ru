class StudentCard
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public Student Student { get; set; }

    public override string ToString()
    {
        return $@"
Start:  {StartDate.ToShortDateString()}
End:    {EndDate.ToShortDateString()}
";
    }

}
