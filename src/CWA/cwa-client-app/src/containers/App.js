import React, { Component } from 'react';
import './App.css';
import Layout from '../components/Layout/Layout';
import Home from '../components/Home/Home';
import { BrowserRouter, Switch, Route } from 'react-router-dom';
import NotFound from '../components/ErrorPages/NotFound/NotFound';
import asyncComponent from '../hoc/AsyncComponent/AsyncComponent';

const AsyncTagList = asyncComponent(() => {
  return import('./Tag/TagList/TagList');
});

const AsyncProductList = asyncComponent(() => {
  return import('./Product/ProductList/ProductList');
});

class App extends Component {
  render() {
    return (
      <BrowserRouter>
        <Layout>
          <Switch>
            <Route path="/" exact component={Home} />
            <Route path="/tags" component={AsyncTagList} />
            <Route path="/products" component={AsyncProductList} />
            <Route path="*" component={NotFound} />
          </Switch>
        </Layout>
      </BrowserRouter>
    );
  }
}
export default App;