using System.Collections.Generic;

namespace Arkivverket.Arkade.Core.Addml.Processes
{
    public class ControlForeignKey : IAddmlProcess, IAddmlFileProcess, IAddmlRecordProcess, IAddmlFieldProcess
    {
        private readonly Dictionary<string, HashSet<string>> _primaryKeys = new Dictionary<string, HashSet<string>>();

        public void Run(Field field)
        {
            if (field.Definition.IsPrimaryKey)
            {
                string file = field.Definition.AddmlFlatFileDefinition.Name;
                string key = file + "_" + field.Definition.Name;

                HashSet<string> primaryKeysForField = null;
                if (_primaryKeys.ContainsKey(key))
                {
                    primaryKeysForField = _primaryKeys[key];
                }
                else
                {
                    primaryKeysForField = new HashSet<string>();
                    _primaryKeys.Add(key, primaryKeysForField);
                }
                primaryKeysForField.Add(field.Value);
            }
            if (field.Definition.ForeignKey != null)
            {
                string foreignKeyReferenceFieldName = field.Definition.ForeignKey.Name;
                string foreignKeyReferenceFileName = field.Definition.ForeignKey.AddmlFlatFileDefinition.Name;
                // save foreign key reference. cannot be sure that the file it references has been parsed yet.
            }
        }

        public void Run(FlatFile flatFile)
        {
        }

        public void Run(Record record)
        {
        }

        public TestRun GetTestRun()
        {
            throw new System.NotImplementedException();
        }

        public void EndOfFile()
        {
            throw new System.NotImplementedException();
        }
    }
}