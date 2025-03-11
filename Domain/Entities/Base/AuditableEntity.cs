namespace Flag_Explorer_App.Domain.Entities.Base
{
    public class AuditableEntity : AbstractEntity
    {
        #region CTOR

        protected AuditableEntity()
            : this(true, Guid.Empty)
        { }


        protected AuditableEntity(bool isActive, Guid id)
            : base(isActive, id)
        {
            DateCreated = DateTime.UtcNow;
            DateModified = DateTime.UtcNow;
        }

        #endregion

        /// <summary>
        /// Created Date
        /// </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Modified Date
        /// </summary>
        public DateTime? DateModified { get; set; }
    }
}
