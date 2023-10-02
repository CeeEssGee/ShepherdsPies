import { useEffect, useState } from "react";
import { deleteOrder, getOrders } from "../../managers/orderManager";
import { Button, Table } from "reactstrap";
import { useNavigate } from "react-router-dom";


export const OrderList = () => {
    const [orders, setOrders] = useState([]);
    const [filteredOrders, setFilteredOrders] = useState([]);

    const navigate = useNavigate();

    useEffect(() => {
        getOrders().then(setOrders);
    }, []);

    const handleDelete = (id) => {
        deleteOrder(id).then(() => {
            getOrders().then(setOrders);
        })
    }

    return (
        <div className="container">
            <div className="sub-menu bg-light">
                <h4>Orders</h4>
                <Table>
                    <thead>
                        <tr></tr>
                        <th>Id #</th>
                        <th>Order Date / Time</th>
                        <th>EE Order Taken By</th>
                        <th>Table#</th>
                        <th>EE Driver</th>
                        <th>Total Cost</th>
                        <th></th>
                        <th></th>
                    </thead>
                    <tbody>
                        {orders.map((o) => (
                            <tr key={`orders-${o.id}`}>
                                <th scope="row">{o.id}</th>
                                <td>{o.dateTimePlaced.split("T")[0]} / {o.dateTimePlaced.split("T")[1]} </td>
                                <td>{o.employee.firstName} {o.employee.lastName}</td>
                                <td>{o.tableNumber}</td>
                                <td>{o?.driver?.firstName} {o?.driver?.lastName} </td>
                                <td>{o.totalCost.toLocaleString("en-US", { style: "currency", currency: "USD" })}</td>
                                <td><Button color="info"
                                    onClick={() => {
                                        navigate(`${o.id}`);
                                    }}
                                >Details</Button></td>
                                <td><Button color="danger"
                                    onClick={() => {
                                        handleDelete(o.id);
                                    }}
                                >Delete</Button></td>
                            </tr>
                        ))}
                    </tbody>
                </Table>
            </div>
        </div>
    )
}