namespace api.DAL;

    public class Dropdownlists
    {

        XDocument doc = XDocument.Load("conf/dropdownlists.xml");
        XDocument epadoc = XDocument.Load("conf/epa.xml");



        public List<Class_Item> getReasonForUse()
        {
            var help = new List<Class_Item>();
            Class_Item cl;

            help.Clear();
            var selected_element = doc.Descendants("Indication");
            IEnumerable<XElement> coll = selected_element.Elements();
            foreach (XElement x in coll)
            {

                cl = new Class_Item();
                cl.Value = (int)x.Element("value");
                cl.Description = (string)x.Element("description");
                help.Add(cl);
            }
            return help;
        }
        internal List<EpaDefinitionDto> getEpaDefinition()
        {
            var help = new List<EpaDefinitionDto>();
            EpaDefinitionDto cl;

            help.Clear();
            var selected_element = epadoc.Descendants("epa");
            foreach (XElement x in selected_element)
            {

                cl = new EpaDefinitionDto();
                cl.Id = Convert.ToInt32(x.Element("ID").Value);
                cl.Definition = x.Element("description").Value;

                help.Add(cl);
            }
            // now add the stuff from the database
            return help;
        }
    }

