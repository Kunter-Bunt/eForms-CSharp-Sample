using eForms_CSharp_Sample_App.models;
using System.Text;

namespace eForms_CSharp_Sample_App.extensions
{
    public static class schematronoutputExtensions
    {
        public static bool HasErrors(this schematronoutput output)
        {
            return output.Items.Any(_ => _ is schematronoutputFailedassert);
        }

        public static string BuildErrorString(this schematronoutput output)
        {
            var failures = new StringBuilder();
            foreach (var failure in output.Items.Where(_ => _ is schematronoutputFailedassert).Cast<schematronoutputFailedassert>())
            {
                failures.AppendLine($"{failure.id}:");
                failures.AppendLine($"- {failure.text}");
                failures.AppendLine($"- {failure.location} -> {failure.test}");
                if (failure.diagnosticreference != null)
                    failures.AppendLine($"- {failure.diagnosticreference?.text} -> {failure.diagnosticreference?.diagnostic}");
                failures.AppendLine($"---------------------");
            }
            var failureText = failures.ToString();
            return failureText;
        }
    }
}
