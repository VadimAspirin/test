import java.util.ArrayList;

class Node {
	private int number;
	private ArrayList<Node> relations;
	Node (int number) {
		this.number = number;
		relations = new ArrayList<>();
		}
	public int getNumber () {
		return number;
		}
	public boolean addRelations (Node node) {
		for (Node i : relations)
			if (i.getNumber () == node.getNumber ())
				return false;
		relations.add (node);
		return true;
		}
	public int countRelations () {
		return relations.size ();
		}
	public Node getRelations (int numberRelations) {
		return relations.get (numberRelations);
		}
	}

class NodesSystem {
	private ArrayList<Node> nodes;
	NodesSystem () {
		nodes = new ArrayList<>();
		}
	public boolean findNode (Node node) {
		for (Node i : nodes)
			if (i == node)
				return true;
		return false;
		}
	public boolean addNode (Node node) {
		if (findNode (node))
			return false;
		nodes.add (node);
		return true;
		}
	public int countNodes () {
		return nodes.size ();
		}
	public Node getNode (int numberRelations) {
		return nodes.get (numberRelations);
		}
	public boolean union (Node nodeFirst, Node nodeSecond) {
		if (!(findNode (nodeFirst) && findNode (nodeSecond)))
			return false;
		for (Node i : nodes) {
			if (i == nodeFirst)
				if (!(i.addRelations (nodeSecond)))
					return false;
			if (i == nodeSecond)
				if (!(i.addRelations (nodeFirst)))
					return false;
			}
		return true;
		}
	public boolean find (Node nodeFirst, Node nodeSecond) {
		if (!(findNode (nodeFirst) && findNode (nodeSecond)))
			return false;
		int count = 0;
		for (Node i : nodes) {
			if (i == nodeFirst)
				for (int j = 0; j < i.countRelations(); ++j)
					if (i.getRelations(j) == nodeSecond)
						++count;
			if (i == nodeSecond)
				for (int j = 0; j < i.countRelations(); ++j)
					if (i.getRelations(j) == nodeFirst)
						++count;
			}
		return count == 2;
		}
	}

class Main {
    public static void main (String[] args) {
		NodesSystem nodesSystem = new NodesSystem ();
		nodesSystem.addNode (new Node (0));
		nodesSystem.addNode (new Node (1));
		nodesSystem.addNode (new Node (2));
		nodesSystem.addNode (new Node (3));
		nodesSystem.addNode (new Node (4));
		nodesSystem.union (nodesSystem.getNode(0), nodesSystem.getNode(1));
		nodesSystem.union (nodesSystem.getNode(0), nodesSystem.getNode(2));
		nodesSystem.union (nodesSystem.getNode(3), nodesSystem.getNode(4));
		System.out.println ("Количество узлов в системе: " + nodesSystem.countNodes ());
		System.out.println ("Связи: ");
		for (int i = 0; i < nodesSystem.countNodes (); ++i) {
			System.out.printf ("%d: ", nodesSystem.getNode(i).getNumber());
			for (int j = 0; j < nodesSystem.getNode(i).countRelations(); ++j) {
				System.out.printf ("%d ", nodesSystem.getNode(i).getRelations(j).getNumber());
				}
			System.out.printf ("\n");
			}
		System.out.printf ("Узел %d связан с %d: ", nodesSystem.getNode(0).getNumber(), nodesSystem.getNode(1).getNumber());
		System.out.println (nodesSystem.find(nodesSystem.getNode(0), nodesSystem.getNode(1)));
		System.out.printf ("Узел %d связан с %d: ", nodesSystem.getNode(0).getNumber(), nodesSystem.getNode(4).getNumber());
		System.out.println (nodesSystem.find(nodesSystem.getNode(0), nodesSystem.getNode(4)));
		}
	}
