using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Factory.Models
{
  public class Engineer
  {
    public Engineer()
    {
      Authorizations = new HashSet<EngineerMachine> {};
    }

    public int EngineerId { get; set; }
    [Display(Name = "First Name")]
    [Required, StringLength(40, MinimumLength = 1)]
    public string FirstName { get; set; }
    [Display(Name = "Last Name")]
    [Required, StringLength(40, MinimumLength = 1)]
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
