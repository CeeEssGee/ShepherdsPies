import { useEffect, useState } from "react";
import { deleteOrder, getOrders, getTodaysOrders } from "../../managers/orderManager";
import { Button, Table } from "reactstrap";
import { useNavigate } from "react-router-dom";


export const OrderListToday = () => {
    const [orders, setOrders] = useState([]);
    const [filteredOrders, setFilteredOrders] = useState([]);

    const navigate = useNavigate();

    useEffect(() => {
        getTodaysOrders().then(setOrders);
    }, []);

    const handleDelete = (id) => {
        deleteOrder(id).then(() => {
            getOrders().then(setOrders);
        })
    }

    return (
        <div className="container">
            <div className="sub-menu bg-light">
                <h2>Orders</h2>
                <Button color="success"
                    onClick={() => {
                        navigate(`/order/create`);
                    }}>New Order</Button>
                <Table>
                    <thead>
                        <tr>
                            <th>Id #</th>
                            <th>Order Date / Time</th>
                            <th>EE Order Taken By</th>
                            <th>Table#</th>
                            <th>EE Driver</th>
                            <th>Total Cost</th>
                            <th></th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {orders.map((o) => (
                            <tr key={`orders-${o.id}`}>
                                <th scope="row">{o.id}</th>
                                <td>{o.dateTimePlaced.split("T")[0]} / {o.dateTimePlaced.split("T")[1]} </td>
                                <td>{o.employee.fullName}</td>
                                <td>{o.tableNumber ? o.tableNumber : "N/A"}</td>
                                <td>{o?.driver?.fullName ? o.driver.fullName : "N/A"} </td>
                                <td>{o.totalCost.toLocaleString("en-US", { style: "currency", currency: "USD" })}</td>
                                <td><Button color="info"
                                    onClick={() => {
                                        navigate(`/order/${o.id}`);
                                    }}
                                >Order Details</Button></td>
                                <td><Button color="danger"
                                    onClick={() => {
                                        handleDelete(o.id);
                                    }}
                                >Cancel Order</Button></td>
                            </tr>
                        ))}
                    </tbody>
                </Table>
            </div>
        </div>
    )
}