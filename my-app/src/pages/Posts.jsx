import React, { useEffect, useRef, useState } from "react";
import PostService from "../API/PostService";
import Loader from "../components/UI/Loader/Loader";
import Pagination from "../components/UI/pagination/Pagination";
import { getPageCount } from "../components/utils/pages";
import { useFetching } from "../hooks/useFetching";
import { usePosts } from "../hooks/usePosts";
import PostList from "../components/PostList";
import '../styles/App.css';
import { useObserver } from "../hooks/useObserver";


function Posts() {
  const [posts, setPosts] = useState([])
  const [filter] = useState({ sort: '', query: '' })
  const [totalPages, setTotalPages] = useState(0);
  const [limit] = useState(10);
  const [page, setPage] = useState(1);
  const sortedAndSearchedPosts = usePosts(posts, filter.sort, filter.query)
  const lastElement = useRef()


  const [fetchPosts, isPostsLoading, postError] = useFetching(async (limit, page) => {
    const response = await PostService.getAll(limit, page);
    setPosts([...posts, ...response.data])
    const totalCount = response.headers['x-total-count']
    setTotalPages(getPageCount(totalCount, limit))
  })

  useObserver(lastElement, page < totalPages, isPostsLoading, () => {
    setPage(page + 1);
  })

  useEffect(() => {
    fetchPosts(limit, page)
  }, [page, limit])

  const removePost = (post) => {
    setPosts(posts.filter(p => p.id !== post.id))
  }

  const changePage = (page) => {
    setPage(page)
  }

  return (
    <div className="App">

      {postError &&
        <h1>Произошла ошибка &{postError}</h1>
      }
      <PostList remove={removePost} posts={sortedAndSearchedPosts} title='Comics' />
      <div ref={lastElement}/>
      {isPostsLoading &&
        <div style={{ display: 'flex', justifyContent: 'center', marginTop: 50 }}><Loader /></div>
      }

      <Pagination
        page={page}
        changePage={changePage}        
      />

    </div>
  );
}

export default Posts;
