namespace DP.Core
{
    public class EntityBuilder<C, P> where C : EntityBuilder<C, P>, new() where P : class, new()
    {
        private readonly P _parent = new P();

        public C SetProperty<JProperty>(Action<P, JProperty> setter, JProperty value)
        {
            setter(_parent, value);
            return (C)this;
        }

        public P Build()
        {
            return _parent;
        }
    }
}
