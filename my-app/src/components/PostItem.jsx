import React from "react";
import classes from "./PostItem.module.css"
import {useNavigate} from 'react-router-dom'
const PostItem = (props) => {

  const router = useNavigate()
  function click() {
    console.log(router)
  }
  return (

    <div className={classes.post}>
      <div className={classes.post__content}>
        <div className={classes.desc}>
          <p className={classes.title}>Бетмен и мелкий</p> <br></br>
          Действие комикса происходит в мире, очень похожем на наш; отличие лишь в том, что в этом мире существовали супергерои. Но в 1985 году они под запретом; большинство защитников правосудия вышли на пенсию. Лишь всесильный Доктор Манхэттен продолжает символизировать могущество США, тем самым нарушая хрупкий баланс Холодной Войны. Мир на грани катастрофы — и в этот момент почему-то начинается охота на бывших героев и грандиозная история Алана Мура и Дэйва Гиббонса о войне, мире, справедливости, человечности, жестокости, и, конечно, людях в масках и плащах.
        </div>
        <div className={classes.comic__img}>
          <img src="../img/preview.JPG" alt=""/>
        </div>
        <button className={classes.btn} onClick={() => router(`/posts/${props.post.comicId}`)}>Read</button>
      </div>

      <div className={classes.post__content}>
        <div className={classes.desc}>
          <p className={classes.title}>Бетмен и мелкий</p> <br></br>
          Действие комикса происходит в мире, очень похожем на наш; отличие лишь в том, что в этом мире существовали супергерои. Но в 1985 году они под запретом; большинство защитников правосудия вышли на пенсию. Лишь всесильный Доктор Манхэттен продолжает символизировать могущество США, тем самым нарушая хрупкий баланс Холодной Войны. Мир на грани катастрофы — и в этот момент почему-то начинается охота на бывших героев и грандиозная история Алана Мура и Дэйва Гиббонса о войне, мире, справедливости, человечности, жестокости, и, конечно, людях в масках и плащах.
        </div>
        <div className={classes.comic__img}>
          <img src="../img/preview.JPG" alt=""/>
        </div>
        <button className={classes.btn} onClick={click}>Read</button>
      </div>
      
      <div className={classes.post__content}>
        <div className={classes.desc}>
          <p className={classes.title}>Бетмен и мелкий</p> <br></br>
          Действие комикса происходит в мире, очень похожем на наш; отличие лишь в том, что в этом мире существовали супергерои. Но в 1985 году они под запретом; большинство защитников правосудия вышли на пенсию. Лишь всесильный Доктор Манхэттен продолжает символизировать могущество США, тем самым нарушая хрупкий баланс Холодной Войны. Мир на грани катастрофы — и в этот момент почему-то начинается охота на бывших героев и грандиозная история Алана Мура и Дэйва Гиббонса о войне, мире, справедливости, человечности, жестокости, и, конечно, людях в масках и плащах.
        </div>
        <div className={classes.comic__img}>
          <img src="../img/preview.JPG" alt=""/>
        </div>
        <button className={classes.btn} onClick={click}>Read</button>
      </div>

    </div>


  )
}

export default PostItem;