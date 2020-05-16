using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateRoutesForDroneDelivery
{
    public class Dijkstra
    {
        Dictionary<Vertex, DijkstraValue> DijkstraVector;
        List<Vertex> Selections;
        Network IGraph;
        Vertex InitialVertex;
    
        public Dijkstra(Network graph, Vertex initialVertex)
        {
            this.DijkstraVector = new Dictionary<Vertex, DijkstraValue>();
            this.Selections = new List<Vertex>();
            this.IGraph = graph;
            this.InitialVertex = initialVertex;
        }

        public bool IsConnected(Vertex destination)
        {
            return DijkstraVector[destination].Weight != Network.INFINITE;
        }
    
        public void DijkstraAlgorithm()
        {
            ClearPreviousData();
    
            InitializeDijkstraVector();
            Vertex minWeighted;
    
            while (!IsSolution())
            {
                UpdateDefinitiveValues();
    
                minWeighted = SelectMinDijkstraValue();
    
                if (minWeighted == null)
                    break;
    
                UpdateDijkstraVector(minWeighted);
                Selections.Add(minWeighted);
            }
        }
    
        private void UpdateDefinitiveValues()
        {
            foreach (Vertex selectedVertex in this.Selections)
                DijkstraVector[selectedVertex].IsDefinitive = true;
        }
    
        private void InitializeDijkstraVector()
        {
            foreach (Vertex vertex in IGraph.Graph)
            {
                if (vertex.Name != InitialVertex.Name)
                    DijkstraVector[vertex] = new DijkstraValue(Network.INFINITE, false, vertex);
                else
                    DijkstraVector[vertex] = new DijkstraValue(0, false, vertex);
            }
        }
    
        private bool IsSolution()
        {
            foreach (var dV in this.DijkstraVector)
                if (!dV.Value.IsDefinitive)
                    return false;
            return true;
        }
    
        private Vertex SelectMinDijkstraValue()
        {
            double minWeight = Network.INFINITE;
            Vertex minVertex = null;

            foreach (var key in DijkstraVector)
            {
                if (!key.Value.IsDefinitive)
                {
                    if (key.Value.Weight < minWeight)
                    {
                        minWeight = key.Value.Weight;
                        minVertex = key.Value.Vertex;
                    }
                }
            }

            return minVertex;
        }
    
        private void UpdateDijkstraVector(Vertex selectedVertex)
        {
            double totalWeight;
            Vertex temporal;

            foreach (Edge edge in selectedVertex.Edges)
            {
                temporal = GetVertex(edge.Destination.Name);

                if (temporal != null)
                {
                    if (!DijkstraVector[temporal].IsDefinitive)
                    {
                        totalWeight = DijkstraVector[selectedVertex].Weight + edge.Distance;

                        if (totalWeight < DijkstraVector[temporal].Weight)
                        {
                            DijkstraVector[temporal].Weight = totalWeight;
                            DijkstraVector[temporal].UpdatedBy = selectedVertex;
                        }
                    }
                }
            }
        }

        private Vertex GetVertex(string name)
        {
            foreach (Vertex v in IGraph.Graph)
                if (v.Name == name)
                    return v;
            return null;
        }
    
        public List<Vertex> BuildPath(Vertex destination)
        {
            List<Vertex> path = new List<Vertex> { destination };
            Vertex currentVertex = destination;

            DijkstraVector[InitialVertex].UpdatedBy = InitialVertex;

            while (currentVertex.Name != InitialVertex.Name)
            {
                currentVertex = GetPrevious(currentVertex);
                path.Add(currentVertex);
            }

            path.Reverse();

            return path;
        }

        private Vertex GetPrevious(Vertex vertex)
        {
            return this.DijkstraVector[vertex].UpdatedBy;
        }
    
        private void ClearPreviousData()
        {
            this.Selections.Clear();
            this.DijkstraVector.Clear();
        }
    
        public void UpdateInitialVertex(Vertex newInitialVertex)
        {
            this.InitialVertex = newInitialVertex;
        }
    }
    
    public class DijkstraValue
    {
        public double Weight { set; get; }
        public bool IsDefinitive { set; get; }
        public Vertex Vertex { set; get; }
    
        public Vertex UpdatedBy { set; get; }
    
        public DijkstraValue(double weight, bool isDefinitive, Vertex vertex)
        {
            this.Weight = weight;
            this.IsDefinitive = isDefinitive;
            this.Vertex = vertex;
        }
    }
}
