using System.Collections.Generic;

namespace Factory.Models
{
  public class Machine
  {
    public Machine()
    {
      Authorizations = new HashSet<EngineerMachine> {};
    }
    public int MachineId { get; set; }
    public string ModelName { get; set; }
    public virtual ICollection<EngineerMachine> Authorizations { get; }
  }
}
