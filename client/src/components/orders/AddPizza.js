// import React, { useEffect, useState } from "react";
// import { getOrderById, putOrder } from "../../managers/orderManager";
// import { getAllSizes } from "../../managers/sizeManager";
// import { getAllCheeses } from "../../managers/cheeseManager";
// import { getAllSauces } from "../../managers/sauceManager";
// import { getAllToppings } from "../../managers/toppingsManager";
// import { Alert, Button, FormGroup, Input, InputGroup, InputGroupText, Label } from "reactstrap";
// import { Form, useNavigate } from "react-router-dom";


// export const AddPizza = ({ orderId }) => {
//     const [sizes, setSizes] = useState([]);
//     const [sizeId, setSizeId] = useState(0);
//     const [sauces, setSauces] = useState([]);
//     const [sauceId, setSauceId] = useState(0);
//     const [cheeses, setCheeses] = useState([]);
//     const [cheeseId, setCheeseId] = useState(0);
//     const [toppings, setToppings] = useState([]);
//     const [toppingIds, setToppingIds] = useState([]);
//     const [pizzaToppings, setPizzaToppings] = useState([]);
//     const [pizzas, setPizzas] = useState([]);
//     const [order, setOrder] = useState({});
//     const [tip, setTip] = useState(0.00);


//     const [visible, setVisible] = useState(false);
//     const onDismiss = () => setVisible(false);

//     const navigate = useNavigate();

//     const handleToppingCheck = (e, id) => {
//         const { checked } = e.target;
//         let clone = structuredClone(toppingIds);

//         if (checked) {
//             clone.push(id);

//             const ptClone = structuredClone(pizzaToppings.filter(pt => {
//                 return pt.toppingId !== id;
//             }));

//             const newPizzaTopping = {
//                 toppingId: id,
//                 topping: toppings.find((topping) => topping.id === id),
//                 quantity: 1
//             }
//             ptClone.push(newPizzaTopping);
//             setPizzaToppings(ptClone);
//         } else {
//             setPizzaToppings(structuredClone(pizzaToppings.filter(pt => {
//                 return pt.toppingId !== id;
//             })))
//             clone = toppingIds.filter((ti) => ti !== id);
//         }
//         setToppingIds(clone);
//     }

//     const handlePizzaTopping = (e, t) => {
//         const clone = structuredClone(pizzaToppings.filter(pt => {
//             return pt.toppingId !== t.id;
//         }));

//         const newPizzaTopping = {
//             toppingId: t.id,
//             topping: toppings.find((topping) => topping.id === t.id),
//             quantity: parseInt(e.target.value)
//         };

//         if (!newPizzaTopping.quantity) {
//             newPizzaTopping.quantity = 1;
//         }

//         clone.push(newPizzaTopping);
//         setPizzaToppings(clone);
//     }

//     const handleAddPizza = () => {
//         const clone = structuredClone(pizzas);

//         if (sizeId === 0 || cheeseId === 0 || sauceId === 0) {
//             setVisible(true);
//             return;
//         }

//         const newPizza = {
//             sizeId,
//             size: sizes.find((s) => s.id === sizeId),
//             cheeseId,
//             cheese: cheeses.find((c) => c.id === cheeseId),
//             sauceId,
//             sauce: sauces.find((s) => s.id === sauceId),
//             pizzaToppings: pizzaToppings
//         }

//         clone.push(newPizza);
//         setPizzas(clone);
//         setSizeId(0);
//         setCheeseId(0);
//         setSauceId(0);
//         setPizzaToppings([]);
//         setToppingIds([]);
//     }

//     const handlePlaceOrder = () => {
//         const orderToSend = {
//             tipAmount: tip,
//             pizzas
//         }

//         putOrder(orderToSend)
//             .then(() => {
//                 navigate("/order");
//             });
//     }

//     return (
//         <div className="container">
//             <h4><u>New Order</u></h4>
//             <div className="alert-float">
//                 <Alert color="info" isOpen={visible} toggle={onDismiss}>
//                     Please fill all form inputs
//                 </Alert>
//             </div>
//             <div className="newOrder">
//                 <Form className="newOrderLeft">
//                     <div className="newOrderSelectors">
//                         <FormGroup>
//                             <Label>Size:</Label>
//                             {sizes.map((s) => (
//                                 <div key={`size--${s.id}`}>
//                                     <Label className="newOrderType">{s.name} {s.length}</Label>
//                                     <Input
//                                         className="newOrderTypeCheckbox"
//                                         type="checkbox"
//                                         id={s.id}
//                                         checked={sizeId === s.id}
//                                         onChange={() => {
//                                             setSizeId(s.id);
//                                         }}
//                                     />
//                                 </div>
//                             ))}
//                         </FormGroup>

//                         <FormGroup>
//                             <Label>Sauce:</Label>
//                             {sauces.map((s) => (
//                                 <div key={`sauce--${s.id}`}>
//                                     <Label className="newOrderType">{s.name}</Label>
//                                     <Input
//                                         className="newOrderTypeCheckbox"
//                                         type="checkbox"
//                                         id={s.id}
//                                         checked={sauceId === s.id}
//                                         onChange={() => {
//                                             setSauceId(s.id)
//                                         }}
//                                     />
//                                 </div>
//                             ))}
//                         </FormGroup>

//                         <FormGroup>
//                             <Label>Cheese:</Label>
//                             {cheeses.map((c) => (
//                                 <div key={`cheese--${c.id}`}>
//                                     <Label className="newOrderType">{c.name}</Label>
//                                     <Input
//                                         className="newOrderTypeCheckbox"
//                                         type="checkbox"
//                                         id={c.id}
//                                         checked={cheeseId === c.id}
//                                         onChange={() => {
//                                             setCheeseId(c.id);
//                                         }}
//                                     />
//                                 </div>
//                             ))}
//                         </FormGroup>

//                     </div>
//                     <FormGroup>
//                         <Label>Toppings <br />{`($0.50 each)`}:</Label>
//                         <div className="newOrderToppings">
//                             {toppings.map((t) => (
//                                 <div className="newOrderTopping" key={`topping--${t.id}`}>
//                                     <Label className="newOrderType">{t.name}</Label>
//                                     <Input
//                                         className="newOrderTypeCheckbox"
//                                         type="checkbox"
//                                         checked={!!toppingIds.find((ti) => t.id === ti)}
//                                         onChange={(e) => {
//                                             handleToppingCheck(e, t.id);
//                                         }}
//                                     />
//                                     {
//                                         toppingIds.find((ti) => t.id === ti)
//                                             ?
//                                             <React.Fragment>
//                                                 <Input
//                                                     className="newOrderToppingAmount"
//                                                     style={{ width: 50 }}
//                                                     type="number"
//                                                     min={1}
//                                                     defaultValue={1}
//                                                     onChange={(e) => {
//                                                         handlePizzaTopping(e, t);
//                                                     }}
//                                                 />
//                                             </React.Fragment>
//                                             :
//                                             ""
//                                     }
//                                 </div>
//                             ))}
//                         </div>
//                     </FormGroup>
//                     <div className="newOrderAddPizza">
//                         <Button
//                             color="link"
//                             onClick={() => {
//                                 handleAddPizza();
//                             }}
//                         >+ Add a Pizza</Button>
//                     </div>

//                     <FormGroup>
//                         <Label htmlFor="tip">Tip:</Label>
//                         <InputGroup>
//                             <InputGroupText>
//                                 $
//                             </InputGroupText>
//                             <input
//                                 style={{
//                                     width: '18rem'
//                                 }}
//                                 name="tip"
//                                 type="number"
//                                 bssize="sm"
//                                 min="0.00"
//                                 step="0.01"
//                                 presicion={2}
//                                 onChange={(e) => {
//                                     setTip(parseFloat(e.target.value));
//                                 }}
//                             />
//                         </InputGroup>
//                     </FormGroup>
//                     <Button
//                         onClick={() => {
//                             handleAddPizza();
//                         }}>
//                         Add to Cart
//                     </Button>
//                 </Form>
//                 <div className="newOrderRight">
//                     <div className="newOrderCart">
//                         <h5 className="newOrderCartHeader"><b><u>Cart</u></b></h5>
//                         <div className="newOrderCartPizzas">
//                             {pizzas.map((p) => (
//                                 <div key={`orderCartPizza--${pizzas.indexOf(p) + 1}`}>
//                                     <b><u>#{pizzas.indexOf(p) + 1}. {sizes[p.sizeId - 1].name} Pizza</u></b><br />
//                                     <b>Cheese:</b> {cheeses[p.cheeseId - 1].type}<br />
//                                     <b>Sauce:</b> {sauces[p.sauceId - 1].type}<br />
//                                     <b>Toppings: </b>
//                                     <ul>
//                                         {p.pizzaToppings.map((pt) => (
//                                             <li key={`orderCartPizzaTopping${pizzas.indexOf(p) + 1}--${pizzas[pizzas.indexOf(p)].pizzaToppings.indexOf(pt)}`}>
//                                                 <div>{toppings[pt.toppingId]?.name} {`(${pt.quantity})`}</div>
//                                             </li>
//                                         ))}
//                                     </ul>
//                                 </div>
//                             ))}
//                         </div>
//                         <div className="newOrderCartTotal">
//                             Total:
//                         </div>
//                         <div className="newOrderCartButton">
//                             <Button
//                                 style={{ width: 170 }}
//                                 onClick={() => {
//                                     handlePlaceOrder();
//                                 }}>
//                                 Place Order
//                             </Button>
//                         </div>
//                     </div>
//                 </div>
//             </div>
//         </div>
//     )

// }