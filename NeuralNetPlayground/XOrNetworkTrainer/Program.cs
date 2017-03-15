using System;
using System.Collections.Generic;
using System.Linq;
using NeuralNetFramework;
using Networks.Example.XOr;

namespace XOrNetworkTrainer
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World");

			var network = new Network();

			// Assign training data:
			network.Input1.Sum = 1;
			network.Input2.Sum = 1;

			ForwardPropagate(network);

			Console.ReadLine();
		}

		private static void ForwardPropagate(Network network)
		{
			var inputNodes = new List<Node> { network.Input1, network.Input2 };

			// Reset all values:
			network.Output.Sum = 0;
			foreach(var node in network.HiddenLayer)
			{
				node.Sum = 0;
			}

			// Forward propagate from input nodes to hidden layer.
			foreach (var synapse in network
				.Synapses
				.Where(s => inputNodes.Any(n => n.Equals(s.InputNode))))
			{
				synapse.OutputNode.Sum += synapse.InputNode.Result * synapse.Weight;
			}

			// Forward propagate fromo hidden layer to output.
			foreach(var synapse in network
				.Synapses
				.Where(s => network.HiddenLayer.Any(n => n.Equals(s.InputNode))))
			{
				synapse.OutputNode.Sum += synapse.InputNode.Result * synapse.Weight;
			}

			Console.WriteLine("Output Node Value: {0}", network.Output.Result);
		}

		private void BackwardPropogate(Network network, double calculatedResult)
		{
			const double target = 0;

			var outputMarginOfError = target - calculatedResult;

			// ******* Hack - using linear activation methods so d/dx == 1
			var deltaOutputSum = 1.0 * outputMarginOfError;

			var deltaWeights = 
		}
	}
}
