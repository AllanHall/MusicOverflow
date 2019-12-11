import React, { useState, useEffect } from 'react'
import Axios from 'axios'
import { Link } from 'react-router-dom'

export default function Home() {
  const [searchTerm, setSearchTerm] = useState('')
  const [feed, setFeed] = useState([])

  useEffect(() => {
    Axios.get(
      `https://localhost:5001/api/feed`.then(resp => {
        console.log({ resp })
        setFeed(resp.data)
      })
    )
  }, [])

  const search = e => {
    e.preventDefault()
    Axios.get('/api/search?searchTerm=' + searchTerm).then(resp => {
      setFeed(resp.data)
    })
  }

  return (
    <div>
      <form onSubmit={search}>
        <input
          type="search"
          value={searchTerm}
          onChange={e => setSearchTerm(e.target.value)}
        />
        <button>Search</button>
      </form>
      <ul className="feed">
        {feed.map(index => {
          return (
            <li key={index}>
              <Link>
                <h2>{index.title}</h2>
              </Link>
            </li>
          )
        })}
      </ul>
    </div>
  )
}
