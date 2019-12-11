import React, { Component } from 'react'
import Axios from 'axios'

class Post extends Component {
  constructor(props) {
    super(props)
    this.state = {
      post: {}
    }
  }

  updateValue = event => {
    const state = this.state
    state.post[event.target.name] = event.target.value
    this.setState(state)
  }

  submitPost = event => {
    event.preventDefault()
    Axios.post('api/feed', this.state.post)
  }

  render() {
    return (
      <section>
        <div>
          <h2> What is your question?</h2>
          <form onSubmit={this.submitPost}>
            <input
              type="text"
              placeholder="What is your post title?"
              onChange={this.updateValue}
            />
            <textarea
              rows="20"
              cols="100"
              onChange={this.updateValue}
              placeholder="Tell us more about your question, be specific."
            />
            <button>
              <h3>Submit</h3>
            </button>
          </form>
        </div>
      </section>
    )
  }
}
export default Post
