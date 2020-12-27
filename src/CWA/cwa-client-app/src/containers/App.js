import React, { Component } from 'react';
import './App.css';
import Layout from '../components/Layout/Layout';
import Home from '../components/Home/Home';
import { BrowserRouter, Switch, Route } from 'react-router-dom';
import NotFound from '../components/ErrorPages/NotFound/NotFound';
import InternalError from '../components/ErrorPages/InternalError/InternalError';
import asyncComponent from '../hoc/AsyncComponent/AsyncComponent';
import CreateTag from './Tag/CreateTag/CreateTag';
import UpdateTag from './Tag/UpdateTag/UpdateTag';
import CreateProduct from './Product/CreateProduct/CreateProduct';
import UpdateProduct from './Product/UpdateProduct/UpdateProduct';

const AsyncTagList = asyncComponent(() => {
  return import('./Tag/TagList/TagList');
});

const AsyncProductList = asyncComponent(() => {
  return import('./Product/ProductList/ProductList');
});

const AsyncTagDetails = asyncComponent(() => {
  return import('./Tag/TagDetails/TagDetails');
});

const AsyncProductDetails = asyncComponent(() => {
  return import('./Product/ProductDetails/ProductDetails');
});

class App extends Component {
  render() {
    return (
      <BrowserRouter>
        <Layout>
          <Switch>
            <Route path="/" exact component={Home} />
            <Route path="/tags" component={AsyncTagList} />
            <Route path="/tagDetails/:id" component={AsyncTagDetails} />
            <Route path="/createTag" component={CreateTag} />
            <Route path="/updateTag/:id" component={UpdateTag} />
            <Route path="/products" component={AsyncProductList} />
            <Route path="/productDetails/:id" component={AsyncProductDetails} />
            <Route path="/createProduct" component={CreateProduct} />
            <Route path="/updateProduct/:id" component={UpdateProduct} />
            <Route path="/500" component={InternalError} />
            <Route path="*" component={NotFound} />
          </Switch>
        </Layout>
      </BrowserRouter>
    );
  }
}
export default App;