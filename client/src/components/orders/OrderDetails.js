import { useEffect, useState } from "react"
import { useNavigate, useParams } from "react-router-dom";
import { getOrderById } from "../../managers/orderManager";
import { Button, Table } from "reactstrap";
import { deletePizza } from "../../managers/pizzaManager";


export const OrderDetails = () => {
    const [order, setOrder] = useState(null);

    const { orderId } = useParams();
    const navigate = useNavigate();

    useEffect(() => {
        getOrderById(orderId).then(setOrder);
    }, []);

    const handleDelete = (pizzaId) => {
        deletePizza(pizzaId)
    }

    if (order == null) {
        return "";
    }

    return (
        <div className="container">
            <h2>Order {orderId}</h2>
            <Button color="info"
                onClick={() => {
                    navigate(`/order/edit/${orderId}`)
                }}
            >Edit Order</Button>
            <Table>
                <tbody>
                    <tr>
                        <th>Order Date / Time</th>
                        <th>Employee</th>
                        <th>Driver</th>
                        <th>Table Number</th>
                        <th>Quantity of Pizzas</th>
                        <th>Tip Amount</th>
                        <th>Total Cost</th>
                        <th></th>
                    </tr>
                    <td>{order?.dateTimePlaced}</td>
                    <td>{order?.employee?.fullName} </td>

                    <td>{order?.driver?.fullName ? order.driver.fullName : "N/A"}
                    </td>

                    <td>{order?.tableNumber ? order.tableNumber : "N/A"}</td>

                    <td>{order?.pizzas.length}</td>
                    <td>{order?.tipAmount}</td>
                    {/* .toLocaleString("en-US", { style: "currency", currency: "USD" }) */}
                    <td>{order?.totalCost}</td>
                    {/* .toLocaleString("en-US", { style: "currency", currency: "USD" }) */}
                </tbody>
            </Table>
            <h4>Pizza Details</h4>
            <Table>
                <thead>
                    <tr>
                        <th>Pizza #</th>
                        <th>Cost</th>
                        <th>Size</th>
                        <th>Sauce</th>
                        <th>Cheese</th>
                        <th></th>
                        <th>Toppings</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        order?.pizzas?.map((p) => {
                            return (
                                <tr key={`pizza--${p.id}`}>
                                    <td>{p.id}</td>
                                    <td>{p.cost}</td>
                                    {/* .toLocaleString("en-US", { style: "currency", currency: "USD" }) */}
                                    <td>{p.size.name}</td>
                                    <td>{p.sauce.name}</td>
                                    <td>{p.cheese.name}</td>
                                    <td>{p.toppings}</td>

                                    <td>{p?.pizzaToppings?.map((pt) =>
                                        <div key={`pizzaTopping--${pt.id}`}>{pt?.topping?.name}</div>
                                    )}</td>
                                    <td><Button color="danger"
                                        value={p.id}
                                        onClick={() => { handleDelete(p.id) }}
                                    >Delete Pizza</Button></td>
                                </tr>
                            )
                        })

                    }
                </tbody>
            </Table>
        </div>
    )
}