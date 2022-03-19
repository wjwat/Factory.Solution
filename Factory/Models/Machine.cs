using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Factory.Models
{
  public class Machine
  {
    public Machine()
    {
      Authorizations = new HashSet<EngineerMachine> {};
    }

    public int MachineId { get; set; }

    [Display(Name = "Model Name")]
    [Required, StringLength(60, MinimumLength = 1)]
    public string ModelName { get; set; }
    public virtual ICollection<EngineerMachine> Authorizations { get; }
  }
}
