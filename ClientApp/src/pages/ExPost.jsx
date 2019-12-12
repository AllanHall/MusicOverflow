import React, { useEffect, useState } from 'react'
import Axios from 'axios'

export default function ExPost(props) {
  const [post, setPost] = useState({})
  const [comments, setComments] = useState([])
  const [postComment, setPostComment] = useState({})
  const [vote, setVote] = useState(0)
  const postID = props.match.params.id
  const API_URL = `https://localhost:5001/api/answers/${postID}`

  useEffect(() => {
    Axios.get(`api/questions/${postID}`).then(resp => {
      setPost({
        title: resp.data.title,
        description: resp.data.description,
        postVote: resp.data.vote
      })
      // setComments({
      //   comments: resp.data.comments
      // })
    })
  }, [])

  const submitComment = e => {
    e.preventDefault()
    // setPostComment()
    Axios.post('/api/comments', { postComment })
    useEffect(() => {
      Axios.post(`${API_URL}`).then(resp => {
        console.log({ resp })
        setComments(resp.data)
      })
    }, [])
  }

  return (
    <section>
      <div>
        <h1>{post.title}</h1>
        <p>{post.description}</p>
        <form onSubmit={() => submitComment()}>
          <textarea
            row="10"
            cols="80"
            placeholder="Comment..."
            name="comment"
          />
          <button>Submit</button>
        </form>
      </div>
      <ul>
        {comments.map(index => {
          return (
            <li key={index}>
              <p>{index.description}</p>
            </li>
          )
        })}
      </ul>
    </section>
  )
}
