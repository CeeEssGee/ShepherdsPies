import { useParams } from "react-router-dom"


export const OrderEdit = () => {

    const { orderId } = useParams();


    return (
        <p>Edit Order {orderId}</p>
    )
}