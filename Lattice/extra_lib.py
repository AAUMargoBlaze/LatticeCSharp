import random
from lattice import Node
from lattice import VisualEdge as Edge
from lattice import BBTree, Graph

node_list = []

def reset_graph(graph_name):
    global node_list
    node_list = [x for x in node_list if x["graph_name"] != graph_name]
    return Graph()

def clone(node_name, graph_name):
    random_string = ''.join(random.choices("abcdefghijklmnopqrstuvwxyz", k=10))
    for i, entry in enumerate(node_list):
        if entry["name"] == node_name and entry["graph_name"] == graph_name:
            # Clone the node object into a new object
            old_node = node_list[i]["node"]
            new_node._pointer = old_node.data()
        # Overwrite the list entry with the new node object and random string
            node_list[i] = {
                "name": node_name,
                "actual_name": random_string,
                "graph_name": graph_name,
                "node": new_node
            }

            # Return the new node object
            return random_string, new_node

def clone_variable(variable_name, variable_value, graph_name):
    random_string = ''.join(random.choices("abcdefghijklmnopqrstuvwxyz", k=10))
    if isinstance(variable_value, Node):
        node = variable_value.copy()
    else:
        node = Node(variable_value)
    node_list.append({
        "name": variable_name,
        "actual_name": random_string,
        "graph_name": graph_name,
        "node": node
    })
    return random_string, node


def reference(node_name, graph_name, node):
    node_list.append({
        "name": node_name,
        "actual_name": node_name,
        "graph_name": graph_name,
        "node": node
    })
    return node

def get_node_from_list(name, graph_name):
    found = None
    for i, entry in enumerate(node_list):
        if entry["name"] == name and entry["graph_name"] == graph_name:
            found = entry["node"]
    if found == None:
        for i, entry in enumerate(node_list):
            if entry["name"] == name:
                found =  entry["node"]
    return found

def sync_nodes_after_rel(pred_graph_name, succ_graph_name):
    if(pred_graph_name == succ_graph_name):
        return 
    nodes_to_be_copied = [x for x in node_list if x["graph_name"] == succ_graph_name]
    nodes_already_there= [x for x in node_list if x["graph_name"] == pred_graph_name]

    for entry in nodes_to_be_copied:
        found = False
        for target_entry in nodes_already_there:
            if target_entry["node"]._fingerprint.int == entry["node"]._fingerprint.int:
                found = True
        if not found:
            random_string = ''.join(random.choices("abcdefghijklmnopqrstuvwxyz", k=10))
            node_list.append({
                "name": random_string,
                "actual_name": random_string,
                "graph_name": pred_graph_name,
                "node": entry["node"]
            })
    
def clone_graph(src_graph_name, target_graph_name,target_graph):
    clone_lookup = {}
    for i, entry in enumerate(node_list):
        if entry["graph_name"] == src_graph_name:
            random_string = ''.join(random.choices("abcdefghijklmnopqrstuvwxyz", k=10))
            # Clone the node object into a new object
            old_node = node_list[i]["node"]
            new_node = old_node.copy()
            clone_lookup[node_list[i]["node"]._fingerprint.int] = new_node
            # Overwrite the list entry with the new node object and random string
            node_list.append({
                "name": node_list[i]["name"],
                "actual_name": random_string,
                "graph_name": target_graph_name,
                "node": new_node
            })
            kwargs = {random_string: new_node}
            target_graph.add_nodes(**kwargs)

    for i, entry in enumerate(node_list):
        og_predecessor_node = entry["node"]
        if entry["graph_name"] == src_graph_name:
            for rel in entry["node"].successors:
                    label = rel[0]._label
                    pred_id = og_predecessor_node._fingerprint.int
                    succ_id  = rel[1]._fingerprint.int
            
                    pred = None
                    succ = None
                    
                    try:
                        pred = clone_lookup[pred_id]
                    except:
                        for entry in node_list:
                            if entry["node"]._fingerprint.int == pred_id:
                                pred = entry["node"]
                    try:
                        succ = clone_lookup[succ_id]
                    except:
                        succ = rel[1].copy()
                        random_string = ''.join(random.choices("abcdefghijklmnopqrstuvwxyz", k=10))
                        node_list.append({
                            "name": random_string,
                            "actual_name": random_string,
                            "graph_name": target_graph_name,
                            "node": succ
                        })
                        kwargs = {random_string: succ}
                        target_graph.add_nodes(**kwargs)
                    pred.add_edge(Edge(label), succ)

def which_graph(node):
    for entry in node_list:
        if entry["node"]._fingerprint.int == node._fingerprint.int:
            return entry["graph_name"]
