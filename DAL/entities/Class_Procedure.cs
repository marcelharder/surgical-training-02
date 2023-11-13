namespace api.DAL.models;


    public class Class_Procedure
    {
        [Key]
        public virtual int ProcedureId { get; set; }
        public virtual int Hospital { get; set; }
        public virtual int RefPhys {get; set;}
        public virtual string EmailHash {get; set;}
        public int FdType { get; set; }
        public virtual DateTime DateOfSurgery { get; set; }
        public virtual String Sequence { get; set; }
        public virtual int SelectedSurgeon { get; set; }
        public virtual int SelectedResponsibleSurgeon { get; set; }
        public virtual int SelectedAnaesthesist { get; set; }
        public virtual int SelectedAssistant { get; set; }
        public virtual int SelectedPerfusionist { get; set; }
        public virtual int SelectedNurse1 { get; set; }
        public virtual int SelectedNurse2 { get; set; }
        public virtual String Description { get; set; }
        public virtual Boolean SurgeryBeforeNextWorkingDay { get; set; }
        public virtual int SelectedTiming { get; set; }
        public virtual int SelectedUrgentTiming { get; set; }
        public virtual int SelectedEmergencyTiming { get; set; }
        public virtual int SelectedStartHr { get; set; }
        public virtual int SelectedStartMin { get; set; }
        public virtual int SelectedStopHr { get; set; }
        public virtual int SelectedStopMin { get; set; }
        public virtual int TotalTime { get; set; }
        public virtual int SelectedInotropes { get; set; }
        public virtual int SelectedPacemaker { get; set; }
        public virtual int SelectedPericard { get; set; }
        public virtual int SelectedPleura { get; set; }
        public virtual String Comment1 { get; set; }
        public virtual String Comment2 { get; set; }
        public virtual String Comment3 { get; set; }
     
    }

