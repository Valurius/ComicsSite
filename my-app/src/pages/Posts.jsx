import React, { useEffect, useRef, useState } from "react";
import PostService from "../API/PostService";
import Loader from "../components/UI/Loader/Loader";
import { useFetching } from "../hooks/useFetching";
import { usePosts } from "../hooks/usePosts";
import PostList from "../components/PostList";
import '../styles/App.css';


function Posts() {
  const [posts, setPosts] = useState([])
  const [filter] = useState({ sort: '', query: '' })
  const sortedAndSearchedPosts = usePosts(posts, filter.sort, filter.query)
  const lastElement = useRef()


  const [fetchPosts, isPostsLoading, postError] = useFetching(async () => {
    const response = await PostService.getAll();
    setPosts([...posts, ...response.data])
  })

  useEffect(() => {
    fetchPosts()
  }, [])

  return (
      <div className="App">

        {postError &&
          <h1>Произошла ошибка &{postError}</h1>
        }
        <PostList posts={sortedAndSearchedPosts} title='Comics' />
        <div ref={lastElement} />
        {isPostsLoading &&
          <div style={{ display: 'flex', justifyContent: 'center', marginTop: 50 }}><Loader /></div>
        }

      </div>
  );
}

export default Posts;
