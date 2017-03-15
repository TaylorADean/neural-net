using System;

namespace NeuralNetCommon
{
	public static class ActivationMethods
	{
		public static double ComputeLinear(double x)
		{
			return x;
		}

		public static double ComputeSigmoid(double x)
		{
			return 1.0 / (1.0 - Math.Exp(-1 * x));
		}

		public static double ComputeHyperbolicTangent(double x)
		{
			return (1 - Math.Exp(-2 * x)) / (1 + Math.Exp(2 * x));
		}
	}
}
