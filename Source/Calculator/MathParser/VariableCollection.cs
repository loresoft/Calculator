using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Calculator.MathParser
{
    public class VariableCollection : Dictionary<string, double>
    {
        private MathEvaluator _evaluator;

        internal VariableCollection(MathEvaluator evaluator) : base(StringComparer.OrdinalIgnoreCase)
        {
            _evaluator = evaluator;
            base.Add(MathEvaluator.AnswerVariable, 0);
            base.Add("pi", Math.PI);
            base.Add("e", Math.E);
        }

        public new void Add(string name, double value)
        {
            Validate(name);
            base.Add(name, value);
        }

        private void Validate(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");

            if (_evaluator.IsFunction(name))
                throw new ArgumentException(
                    string.Format("The variable name conflicts with function '{0}'.", name), "name");

            for (int i = 0; i < name.Length; i++)
                if (!char.IsLetter(name[i]))
                    throw new ArgumentException("The variable name can only contain letters.", "name");


        }
    }
}
