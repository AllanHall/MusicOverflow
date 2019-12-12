import React, { Component } from 'react'
import { Route } from 'react-router'
import { Layout } from './components/Layout'
import { Home } from './pages/Home'
import { ExPost } from './pages/ExPost'
import { Post } from './pages/Post'

export default class App extends Component {
  static displayName = App.name

  render() {
    return (
      <Layout>
        <Route exact path="/" component={Home} />
        <Route path="/Post" component={Post} />
        <Route path="/Post/:id" component={ExPost} />
      </Layout>
    )
  }
}
