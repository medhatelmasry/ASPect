using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ASPectLibrary
{
    // A class used for student peer evaluations on projects
    public class PeerEvaluation
    {
        [Key]
        //ID of the PeerEvaluation
        public int PeerEvaluationId {get; set; }
        //ID of the project 
        public int ProjectId { get; set; }
        //User that is doing the evaluation
        public string UserEvaluatingId { get; set; }
        //User that is receiving the evaluation
        public string UserBeingEvaluatedId { get; set; }
        //Comments from the student that is doing the evaluation
        public string Comments { get; set; }
        //A rating from 0 to 10(inclusive) on how the student is doing
        [Range(0,10)]
        public int Rating { get; set; }
        //Date the evaluation was done
        public DateTime Date { get; set; }


        [ForeignKey("UserEvaluatingId")]
        public ApplicationUser UserEvaluating { get; set; }

        [ForeignKey("UserBeingEvaluatedId")]
        public ApplicationUser UserBeingEvaluated { get; set; }

        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
    }
    
}