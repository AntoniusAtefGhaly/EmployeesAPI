using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EmployeesAPI.Data.Entities
{
    public class EmployeeTaxs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public float Tax { get; set; }
        public float NetSalary { get; set; }
        public Guid EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee{ get; set; }
}
}
