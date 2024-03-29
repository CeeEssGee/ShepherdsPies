import { Route, Routes } from "react-router-dom";
import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import Login from "./auth/Login";
import Register from "./auth/Register";
import { OrderList } from "./orders/OrderList";
import { OrderDetails } from "./orders/OrderDetails";
import { OrderEdit } from "./orders/OrderEdit";
import { OrderCreate } from "./orders/OrderCreate";
import { OrderListToday } from "./orders/OrderListToday";


export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
  return (
    <Routes>
      <Route path="/">
        <Route
          index
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <OrderList />
            </AuthorizedRoute>
          }
        />


        <Route path="order">
          <Route
            index
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <OrderList />
              </AuthorizedRoute>
            }
          />

          <Route
            path="today"
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <OrderListToday />
              </AuthorizedRoute>
            }
          />

          <Route
            path=":orderId"
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <OrderDetails />
              </AuthorizedRoute>
            }
          />

          <Route
            path="edit/:id"
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <OrderEdit />
              </AuthorizedRoute>
            }
          />

          <Route
            path="create"
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <OrderCreate />
              </AuthorizedRoute>
            }
          />

        </Route>





        <Route
          path="login"
          element={<Login setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path="register"
          element={<Register setLoggedInUser={setLoggedInUser} />}
        />
      </Route>
      <Route path="*" element={<p>Whoops, nothing here...</p>} />
    </Routes>
  );
}
