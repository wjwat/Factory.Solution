using System.Collections.Generic;

namespace Factory.Models
{
  public class Engineer
  {
    public Engineer()
    {
      Authorizations = new HashSet<EngineerMachine> {};
    }

    public int EngineerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Name
    {
      get
      {
        return FirstName + " " + LastName;
      }
    }
    public virtual ICollection<EngineerMachine> Authorizations { get; }
  }
}
