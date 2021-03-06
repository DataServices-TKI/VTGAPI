//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VTGWebAPI.App_Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Questionnaire
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Questionnaire()
        {
            this.QuestionnaireResults = new HashSet<QuestionnaireResult>();
        }
    
        public int QuestionnaireId { get; set; }
        public int VisitId { get; set; }
        public string Description { get; set; }
        public Nullable<int> TypeQuestionnaireId { get; set; }
        public Nullable<int> WasScheduledAtStudyLevelYN { get; set; }
        public Nullable<System.DateTime> DateIssued { get; set; }
        public Nullable<int> IssuedBy { get; set; }
        public Nullable<System.DateTime> DateReceived { get; set; }
        public Nullable<int> ReceivedBy { get; set; }
        public Nullable<int> IsComplete { get; set; }
        public string Comments { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuestionnaireResult> QuestionnaireResults { get; set; }
        public virtual QuestionnaireType QuestionnaireType { get; set; }
        public virtual Visit Visit { get; set; }
    }
}
