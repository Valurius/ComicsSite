import React from "react";
import { CSSTransition, TransitionGroup } from "react-transition-group";
import PostItem from "./PostItem";
import classes from './PostList.module.css'

const PostList = ({posts, title, remove}) => {
    if(!posts.length){
        return (
            <h1 className={classes.NotFound}>Not found</h1>
        )
    }
    return (
        <div>
            <h1 className={classes.title}>
            {title}
        </h1>
        {posts.map((post, index) =>
            <PostItem key={index} number={index + 1} post={post}/>
            )}
        </div>
    );
};

export default PostList;