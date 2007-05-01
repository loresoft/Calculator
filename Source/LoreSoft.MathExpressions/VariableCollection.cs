using System;
using System.Collections.Generic;
using LoreSoft.MathExpressions.Properties;

namespace LoreSoft.MathExpressions
{
    /// <summary>
    /// Class representing a collection of variable names and values.
    /// </summary>
    /// <remarks>
    /// Variable names can only contain letters, numbers and symbols are not allowed.
    /// </remarks>
    public class VariableCollection : Dictionary<string, double>
    {
        private MathEvaluator _evaluator;

        /// <summary>Initializes a new instance of the <see cref="VariableCollection"/> class.</summary>
        /// <param name="evaluator">The evaluator.</param>
        internal VariableCollection(MathEvaluator evaluator) : base(StringComparer.OrdinalIgnoreCase)
        {
            _evaluator = evaluator;
            base.Add(MathEvaluator.AnswerVariable, 0);
            base.Add("pi", Math.PI);
            base.Add("e", Math.E);
        }

        /// <summary>Adds the specified variable and value to the dictionary.</summary>
        /// <param name="name">The name of the variable to add.</param>
        /// <param name="value">The value of the variable.</param>
        /// <exception cref="ArgumentNullException">When variable name is null.</exception>
        /// <exception cref="ArgumentException">When variable name contains non-letters or the name exists in the <see cref="MathEvaluator.Functions"/> list.</exception>
        /// <seealso cref="MathEvaluator"/>
        /// <seealso cref="MathEvaluator.Variables"/>
        /// <seealso cref="MathEvaluator.Functions"/>
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
                    string.Format(Resources.VariableNameConflict, name), "name");

            for (int i = 0; i < name.Length; i++)
                if (!char.IsLetter(name[i]))
                    throw new ArgumentException(Resources.VariableNameContainsLetters, "name");
        }
    }
}
