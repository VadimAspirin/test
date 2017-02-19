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
	public boolean addRelations (int numberNode) {
		for (Node i : relations)
			if (i.getNumber () == numberNode)
				return false;
		relations.add (new Node (numberNode));
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
	public boolean findNode (int numberNode) {
		for (Node i : nodes)
			if (i.getNumber () == numberNode)
				return true;
		return false;
		}
	public boolean addNode (int numberNode) {
		if (!(findNode (numberNode)))
			return false;
		nodes.add (new Node (numberNode));
		return true;
		}
	public int countNodes () {
		return nodes.size ();
		}
	public Node getNode (int numberRelations) {
		return nodes.get (numberRelations);
		}
	public boolean union (int numberNodeFirst, int numberNodeSecond) {
		if (!(findNode (numberNodeFirst) && findNode (numberNodeSecond)))
			return false;
		for (Node i : nodes) {
			if (i.getNumber () == numberNodeFirst)
				if (!(i.addRelations (numberNodeSecond)))
					return false;
			if (i.getNumber () == numberNodeSecond)
				if (!(i.addRelations (numberNodeFirst)))
					return false;
			}
		return true;
		}
	public boolean find (int numberNodeFirst, int numberNodeSecond) {
		if (!(findNode (numberNodeFirst) && findNode (numberNodeSecond)))
			return false;
		for (Node i : nodes) {
			if (i.getNumber () == numberNodeFirst)
				if (!(i.addRelations (numberNodeSecond)))
					return true;
			if (i.getNumber () == numberNodeSecond)
				if (!(i.addRelations (numberNodeFirst)))
					return true;
			}
		return false;
		}
	}

class Main {
    public static void main (String[] args) {
		NodesSystem nodesSystem = new NodesSystem ();
        System.out.println (nodesSystem.addNode (0));
        nodesSystem.addNode (1);
        nodesSystem.addNode (2);
        nodesSystem.addNode (3);
        nodesSystem.union (0, 1);
        nodesSystem.union (0, 2);
        nodesSystem.union (3, 4);
        System.out.println(nodesSystem.countNodes ());
        for (int i = 0; i < nodesSystem.countNodes (); ++i) {
			System.out.printf ("%d ", nodesSystem.getNode(i).getNumber());
			}
		}
	}
